using System.Collections.Generic;
using System;
using System.Linq;
using CoelsaEntrevista.Entities;
using CoelsaEntrevista.Interfaces;
using CoelsaEntrevista.Interfaces.Repositories;
using Dapper;
using System.Threading.Tasks;

namespace CoelsaEntrevista.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(IConnectionParameters connectionParameters) : base(connectionParameters)
        {

        }    

        public async Task<IEnumerable<Contact>> GetAll( int skip, int take)
        {
            using (var connection = this.GetConnection())
            {
                var contacts =  await connection.QueryAsync<Contact, Company, Contact>(@"                       
                        select * from Contact ct
                        inner join Company cp on cp.IdCompany = ct.IdCompany
                        order by ct.LastName 
                        offset @Skip rows
                        FETCH NEXT @Take rows only"
                      , (contacts, company) =>
                      {
                          contacts.Company = company;
                          return contacts;
                      }, new { Skip = skip, Take = take } , splitOn: "IdCompany");

                return  contacts;
            }
        }
        public async Task Save(Contact domain)
        {
            using (var connection = this.GetConnection())
            {
                var affectedRow = await connection.ExecuteAsync("INSERT INTO Contact ( IdContact, FirstName, LastName, Email, PhoneNumber, IdCompany )VALUES (@IdContact, @FirstName, @LastName, @Email, @PhoneNumber, @IdCompany)", new { IdContact = domain.IdContact, FirstName = domain.FirstName, LastName = domain.LastName, Email = domain.Email, PhoneNumber= domain.PhoneNumber, IdCompany = domain.Company.IdCompany});
            }
        }

        public async Task Update(Contact domain)
        {
            using (var connection = this.GetConnection())
            {
                var affectedRows = await connection.ExecuteAsync("UPDATE Contact SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, IdCompany = @IdCompany WHERE IdContact = @IdContact", new { IdContact = domain.IdContact, FirstName = domain.FirstName, LastName = domain.LastName, Email = domain.Email, PhoneNumber = domain.PhoneNumber, IdCompany = domain.Company.IdCompany });

            }
        }
        public async Task Delete(Guid id)
        {
            using (var connection = this.GetConnection())
            {
                var affectedRows = await connection.ExecuteAsync("DELETE FROM  Contact  WHERE IdContact = @IdContact", new { IdContact = id });
            }
        }

    }
}

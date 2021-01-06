using System.Collections.Generic;
using System.Linq;
using CoelsaEntrevista.Entities;
using CoelsaEntrevista.Interfaces;
using CoelsaEntrevista.Interfaces.Repositories;
using Dapper;

namespace CoelsaEntrevista.Repositories
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(IConnectionParameters connectionParameters) : base(connectionParameters)
        {

        }    
        public IEnumerable<Contact> GetAll()
        {
            using (var connection = this.GetConnection())
            {
                var contacts = connection.Query<Contact, Company, Contact>(@"
                        select * from Contact ct
                        inner join Company cp on cp.IdCompany = ct.IdCompany"
                      , (contacts, company) =>
                      {
                          contacts.Company = company;                          
                          return contacts;
                      }, splitOn: "IdCompany");

                return contacts;
            }
        }

        public IEnumerable<Contact> GetAllPagination( int skip, int take = 10)
        {
            using (var connection = this.GetConnection())
            {
                var contacts = connection.Query<Contact, Company, Contact>(@"                       
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

                return contacts;
            }
        }

    }
}

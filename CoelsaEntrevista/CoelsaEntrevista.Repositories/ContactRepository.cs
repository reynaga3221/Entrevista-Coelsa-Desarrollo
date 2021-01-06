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
                var books = connection.Query<Contact>(@"
                        SELECT * FROM Contacts "
                        );

                return books.AsQueryable();
            }
        }
    }
}

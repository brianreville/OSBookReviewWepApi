using Dapper;
using OSBookReviewWepApi.Models;
using OSDataAccessLibrary;

namespace OSBookReviewWepApi.Services
{
    public class DataClass : IDataClass
    {
        //TODO : Assign SQL Stored Procedure Calls 
        private readonly IDataAccess _data;

        public DataClass(IDataAccess data)
        {
            _data = data;
        }
        // add a single object 
        public async Task<bool> AddAsync(BookReview p)
        {
            return await InsertRecord(p);
        }
        // get indiviudal object type
        public async Task<BookReview> GetIndv(BookReview param)
        {
            return await GetSingle(param);
        }
        // update one if required.
        public async Task<bool> UpdateAsync(BookReview p)
        {
            return await UpdateRecord(p);
        }
        // Update multiple objects at the same time
        public async Task<bool> UpdateAsync(List<BookReview> books)
        {
            return await UpdateList(books);
        }
        // gets a list of authors
        public async Task<List<Author>> GetListAsync()
        {
            return await GetAuthorList();
        }
        // get list of object types with param requirements
        public async Task<List<BookReview>> GetListAsync(int aid)
        {
            return await GetBookList(aid);
        }

        // private methods to handle public calls

        // inserts a single record of an object 
        private async Task<bool> InsertRecord(BookReview p)
        {
            try
            {
                // call stored procedure
                string sql = "";
                // execute stored procedure via 
                var result = await _data.AddAsync(sql, p);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // gets a single object passing a request of that object type in case of multiple param types
        // no current requirement
        private async Task<BookReview> GetSingle(BookReview param)
        {
            // set of dynamic params depending on stored procedure params
            DynamicParameters p = new();


            // set the stored procedure string
            string sql = "";
            // return the result of the DAL call
            return await _data.GetIndvAsync<BookReview, dynamic>(sql, p);
        }
        // updates a record of an object with the object passed for setting dynamic params
        // no current requirement
        private async Task<bool> UpdateRecord(BookReview p)
        {
            // set T type as param object

            // if not object required set dynamic params instead
            //DynamicParameters p = new();

            // set the stored procedure string
            string sql = "";
            // return the result of the DAL call
            return await _data.UpdateAsync(sql, p);

        }
        // updates multiple records
        private async Task<bool> UpdateList(List<BookReview> books)
        {
            try
            {
                int total = books.Count;
                int complete = 0;

                foreach (BookReview p in books)
                {
                    // call stored procedure
                    string sql = "";
                    // execute stored procedure via DAL 
                    var result = await _data.AddAsync(sql, p);

                    if (result)
                    {
                        complete += 1;
                    }
                }

                return total.Equals(complete);
            }
            catch (Exception)
            {
                return false;
            }
        }
        // gets a list of the object type depending on author id
        private async Task<List<BookReview>> GetBookList(int aid)
        {
            try
            {
                DynamicParameters p = new();
                // add params                
                p.Add("@aid", aid);
                // stored prodecure to be called
                string sql = "";

                List<BookReview> books = await _data.GetList<BookReview, dynamic>(sql, p);
                return books;
            }
            catch (Exception)
            {   // returns an empty list of type T in the event of exception being thrown
                List<BookReview> books = new();
                return books;
            }
        }
        // gets a list of authors
        private async Task<List<Author>> GetAuthorList()
        {
            try
            {
                DynamicParameters p = new();
                // add params if any

                // stored procedure to be called
                string sql = "";

                List<Author> authors = await _data.GetList<Author, dynamic>(sql, p);
                return authors;
            }
            catch (Exception)
            {
                // returns an empty list of type T in the event of exception being thrown
                List<Author> authors = new();
                return authors;
            }

        }
    }
}

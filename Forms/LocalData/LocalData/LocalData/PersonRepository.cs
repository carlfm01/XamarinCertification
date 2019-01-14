using LocalData.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace People
{
    public class PersonRepository
    {
        private readonly SQLiteAsyncConnection _conn;

        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);
            _conn.CreateTableAsync<Person>().GetAwaiter().GetResult();
        }

        public async System.Threading.Tasks.Task AddNewPersonAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await _conn.InsertAsync(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async System.Threading.Tasks.Task<List<Person>> GetAllPeopleAsync()
        {
            try
            {
                return await _conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
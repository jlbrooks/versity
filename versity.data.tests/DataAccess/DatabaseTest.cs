using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using versity.data.DataAccess.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using NUnit.Framework;

namespace versity.data.tests.DataAccess
{
    public abstract class DatabaseTest
    {
        public virtual void SetupTransaction()
        {
            _scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });
        }

        public virtual void CloseTransaction()
        {
            _scope.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected VersityDbContext TestDbContext
        {
            get { return Context as VersityDbContext; }
        }

        [SetUp]
        protected virtual void setup() 
        {
            CreateDbContext();
            SetupTransaction();
        }

        [TearDown]
        protected virtual void teardown()
        {
            CloseTransaction();
            Dispose();
        }

        protected virtual void CreateDbContext() 
        {
            Context = new VersityDbContext();
        }

        protected void SaveAndValidate()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            if (Context == null)
                return;
            Context.Dispose();
            Context = null;
        }

        protected DbContext Context;
        private TransactionScope _scope;
    }
}

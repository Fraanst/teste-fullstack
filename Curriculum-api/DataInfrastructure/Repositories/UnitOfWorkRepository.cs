

using System;
using cv.Domain.Contracts.Repository;
using DataInfrastructure.Context;

namespace DataInfrastructure.Repositories
{
	public class UnitOfWorkRepository : IUnitOfWork
	{
		protected CVContext db;

		public UnitOfWorkRepository(CVContext ctx)
		{
			db = ctx;
			// this.Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
		}

		public bool Commit()
		{
			var x = db.SaveChanges();
			return true;
		}

		public bool CommitDo(Action ifCommitAction)
		{
			var commited = Commit();

			if (commited)
			{
				ifCommitAction?.Invoke();
			}

			return commited;
		}
		public void Dispose()
		{
			Dispose(true);
		}
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (db != null)
				{
					db.Dispose();
					db = null;
				}
			}
		}
	}
}

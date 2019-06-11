using cv.Domain.Contracts;
using cv.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
	public class ApplicationServiceBase : NotificationServiceBase
	{
		private IUnitOfWork uow;
		public ApplicationServiceBase(IUnitOfWork _uow, IDomainValidationProvider _notification) : base(_notification)
		{
			uow = _uow;
		}
		public bool Commit()
		{
			return uow.Commit();
		}

		public bool CommitDo(Action idCommitAction)
		{
			return uow.CommitDo(idCommitAction);
		}

		public void Dispose()
		{
			uow.Dispose();
		}
	}
}

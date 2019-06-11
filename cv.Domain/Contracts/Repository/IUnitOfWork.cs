using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Contracts.Repository
{
	public interface IUnitOfWork
	{
		bool Commit();
		bool CommitDo(Action ifCommitAction);
		void Dispose();

	}
}

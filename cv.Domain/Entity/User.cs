using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Entity
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public Curriculum Curriculum { get; set; }
		public int CurriculumId { get; set; }
	}
}

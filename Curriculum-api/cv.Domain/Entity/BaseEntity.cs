using System;
using System.Collections.Generic;
using System.Text;

namespace cv.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        private DateTime? createdAt;
        public DateTime CreatedAt
        {
            get { return createdAt ?? DateTime.UtcNow; }
            set { createdAt = value; }
        }
    }
}

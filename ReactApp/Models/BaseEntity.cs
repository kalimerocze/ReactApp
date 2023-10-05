using System.ComponentModel.DataAnnotations;

namespace ReactApp.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DeletedBy { get; set; }
        //Controll konzistence while saving
        //public byte[]? Timestamp { get; set; }


    }
}

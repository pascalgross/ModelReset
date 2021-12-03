using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Catel.Data;
using Catel.Fody;
using ModelReset.Contracts;

namespace ModelReset.Models
{
    [Table("Parts")]
    [NoWeaving]
    public class Part : ModelBase, IEntityBase
    {
        public string Description { get; set; } = "initial value";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Category Category { get; set; }

    }
}
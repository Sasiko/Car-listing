using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string RegistrationId { get; set; }
        public string Description { get; set; }
        [ForeignKey("VehicleMake")]
        public int MakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        [ForeignKey("VehicleType")]
        public int TypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}

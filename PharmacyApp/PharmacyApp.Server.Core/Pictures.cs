using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public class Pictures
    {
        public class Picture
        {
            [Key]
            public int Id { get; set; }

            public int MedicamentsId { get; set; }

            public string FileName { get; set; }

            public Picture(int medicamentsId, string fileName)
            {
                this.MedicamentsId = medicamentsId;
                this.FileName = fileName;
            }
        }
    }
}

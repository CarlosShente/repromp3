using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//***********************+++
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReproMP3.EN
{
    public class Ccarpeta
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Autor es Obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 Caracteres")]
        public string Autor { get; set; }
        public string Icono { get; set; }
        [Required(ErrorMessage = "URL es Obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 150 Caracteres")]
        public string Url { get; set; }



    }
}

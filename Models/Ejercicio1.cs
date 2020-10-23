using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrabajoFinal_Unidad_I.Models {
    public class Ejercicio1 {
        public double numero { get; set; }
        public int tipo { get; set; }
        public string resultado { get; set; }
        [Range(0, 10, ErrorMessage = "Ingrese rago válido, entre {1} y {2}")]
        public int cantDec { get; set; }
        public int lineas { get; set; }
        public ArrayList proceso { get; set; }
        public ArrayList residuos { get; set; }
        public ArrayList resta { get; set; }
    }
}
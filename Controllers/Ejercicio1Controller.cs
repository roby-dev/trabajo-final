using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoFinal_Unidad_I.Models;
using System.Collections;

namespace TrabajoFinal_Unidad_I.Controllers
{
    public class Ejercicio1Controller : Controller
    {
        // GET: Ejercicio1


        ArrayList proceso = new ArrayList();
        ArrayList residuos = new ArrayList();
        ArrayList resta = new ArrayList();

        public ActionResult Index(Ejercicio1 ejercicio1)
        {
            if(ModelState.IsValid && !string.IsNullOrEmpty(Request.Form["tipo"])) {
                ejercicio1.proceso = new ArrayList();
                ejercicio1.residuos = new ArrayList();
                ejercicio1.resta = new ArrayList();
                string proc = "";
                int res = 0;
                ejercicio1.lineas = 0;
                if (ejercicio1.numero > 0) {
                    switch (ejercicio1.tipo) {
                        case 0:
                            long residuo = (long)ejercicio1.numero;
                            proc = residuo + " / 2 = " + residuo / 2 + " -> residuo = ";
                            while (residuo >= 2) {
                                
                                if (residuo % 2 == 0) {                                 
                                    res = 0;            
                                    ejercicio1.resultado += 0;
                                } else {                                    
                                    res = 1;
                                    ejercicio1.resultado += 1;
                                }
                                residuo = residuo / 2;
                                llenarListas(res, proc);
                                ejercicio1.lineas++;                               
                            }
                            if (residuo == 1) {
                                res = 1;
                                proc = "Residuo final = ";
                                llenarListas(res, proc);
                                ejercicio1.resultado += 1;
                                ejercicio1.lineas++;                                
                            }
                            
                            char[] tmpResultado = ejercicio1.resultado.ToCharArray();
                            Array.Reverse(tmpResultado);
                            ejercicio1.resultado = new string(tmpResultado);

                            if (ejercicio1.cantDec>0) {                                
                                
                                llenarListas(3, "PARTE DECIMAL");

                                string[] numerodiv = ejercicio1.numero.ToString().Split('.');
                                string r = "";
                                decimal decimales = (decimal) ejercicio1.numero - Convert.ToDecimal(numerodiv[0]);
                                string dec="";
                                for (int i = 0; i < ejercicio1.cantDec; i++) {
                                    ejercicio1.lineas++;
                                    decimales = decimales * 2;
                                    proc = (decimales / 2) + " * 2 = " + decimales + " -> entero = ";
                                    if (decimales < 1) {
                                        res = 0;                                        
                                        dec += 0;
                                    } else if (decimales > 1) {                                        
                                        r = "|| Nueva parte decimal = (" + decimales + " - 1) = " + (decimales - 1);
                                        res = 1;                                        
                                        dec += 1;
                                        decimales -= 1;
                                    }
                                    if (decimales == 1) {
                                        proc = "0.5 * 2 = "+decimales + " -> entero final = ";
                                        llenarListas(1, proc);
                                        dec += 1;
                                        break;
                                    }
                                    llenarListas(res, proc,r);
                                }
                                ejercicio1.resultado = ejercicio1.resultado + "." + dec;
                            }

                            break;

                        default:
                            break;
                    }
                }

                ejercicio1.proceso = proceso;
                ejercicio1.residuos = residuos;
                ejercicio1.resta = resta;
            }
            return View(ejercicio1);
        }

        private void llenarListas(int _numero, string _proc,string _resta = "") {
            if (_numero == 3) {
                residuos.Add("GO");
            } else {
                residuos.Add(_numero);
            }
            proceso.Add(_proc);
            resta.Add(_resta);
        }
    }
}
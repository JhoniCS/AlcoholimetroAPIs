using System;
using Microsoft.AspNetCore.Mvc;
using AlcoholimetroApi.entities;



namespace AlcoholimetroApi.Services
{
    public class AlcoholServices
   {
        public string calcular(Personas person)
        {
            
            var tipo = person.Tipo.ToLower();
            var cantidad = person.Cantidad;
            var peso = person.Peso;

            var ml = 0;
            var apml = 0;


            switch (tipo)
            {
                case "CERVEZA": ml = 330; apml = 5; break;
                case "VINO/CAVA": ml = 100; apml = 12; break;
                case "VERMÚ": ml = 70; apml = 17; break;
                case "LICOR": ml = 45; apml = 23; break;
                case "BRENDY": ml = 45; apml = 38; break;
                case "COMBINADO": ml = 50; apml = 38; break;

                case null: return ("No hay valor.");
                default: return ("Error de Tipo Bebida.");

            }
            var totalalcoholconsumido = cantidad*ml;
            
            var totalporbebida = (apml*totalalcoholconsumido)/100;

            var cantidadalcoholasangre = (15*totalporbebida)/100;

            var masaetanolensangre = 0.789*cantidadalcoholasangre;

            var volumenalcoholsangre = (8*peso)/100;

            var alcoholimetro = masaetanolensangre/volumenalcoholsangre;
            
            if(alcoholimetro>0.8)
            {
                return ($"Cantidad de alcohol en la sangre: {alcoholimetro.ToString("F")}. No puede continuar el viaje");
            }
            return ($"Volumen de alcohol en la sangre: {alcoholimetro.ToString("F")}. Continuar el viaje");



            
        }
    }
}
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class AsignaturaInputModel
    {
        public string IdAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
    }

    public class AsignaturaViewModel : AsignaturaInputModel
    {
        public AsignaturaViewModel(){

        }
        public AsignaturaViewModel(Asignatura asignatura){
            IdAsignatura = asignatura.IdAsignatura;
            NombreAsignatura = asignatura.NombreAsignatura;
        }
    }
}
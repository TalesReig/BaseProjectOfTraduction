using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTraducao
{
    internal class GerenciadorGenerico
    {
        private List<GenericClass> genericClassList;

        public GerenciadorGenerico()
        {
            this.genericClassList = new List<GenericClass>();
        }

        public void AddGenericClass(int id, string name)
        {
            GenericClass genericClass = new GenericClass(id, name);
            this.genericClassList.Add(genericClass);
        }

        public bool RemoveGenericClass(int id)
        {
            GenericClass genericClass = this.genericClassList.FirstOrDefault(gc => gc.id == id);
            if (genericClass != null)
            {
                this.genericClassList.Remove(genericClass);
                return true;
            }
            else
                return false;
        }

        public List<GenericClass> AllInstances()
        {
            return this.genericClassList;
        }

        public void ListGenericClasses()
        {
            foreach (GenericClass genericClass in this.genericClassList)
            {
                Console.WriteLine($"ID: {genericClass.id}, Name: {genericClass.name}");
            }
        }
    }
}

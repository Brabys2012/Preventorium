using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preventorium
{ 
    class Menu_layout_all_day
    {   
       public  string professia;


        public  Menu_layout_all_day( string prof)
        {
            professia = prof;

            Menu();
           
        }
        public string Menu()
        {
            return professia;

        }


           
    

    }
}

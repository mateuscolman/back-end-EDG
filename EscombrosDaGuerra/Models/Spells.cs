using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscombrosDaGuerra.Models
{
    public class Spells
    {
        [Key]    
        public int SpellId { get; set; }
     
        public string SpellName { get; set; }

        public int SpellConjurationTime { get; set; }

        // Define qual temporizador
        // 1 = Ação, 2 = Ação Bonus, 3 = Minutos, 4 = Horas
        public short SpellConjurationTimer { get; set; }

        public string SpellRange { get; set; }       

        // 0 = Não, 1 = Sim                  
        public short SpellComponentVerbal { get; set; }

        // 0 = Não, 1 = Sim        
        public short SpellComponentSomatic { get; set; }

        // 0 = Não, 1 = Sim  
        public short SpellComponentMaterial { get; set; }
        
        public string SpellComponentMaterialDesc { get; set; }

        // 0 = Não, 1 = Sim      
        public short SpellConcentration { get; set; }

        // Em minutos        
        public string SpellDuration { get; set; }

        public int SpellLevel { get; set; }

        public string SpellSchool { get; set; }

        // Informa se a magia precisa de um ritual
        // 0 = Não, 1 = Sim        
        public short SpellRitual { get; set; }

        public string SpellDescription { get; set; }
    }
}

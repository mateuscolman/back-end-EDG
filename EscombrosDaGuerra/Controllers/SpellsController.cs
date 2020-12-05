using EscombrosDaGuerra.DataBase;
using EscombrosDaGuerra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscombrosDaGuerra.Controllers
{
    [Route("api/spells")]
    public class SpellsController : ControllerBase
    {

        #region 'Constructor'

        private readonly EGContext _data;

        public SpellsController(EGContext data)
        {
            _data = data;
        }

        #endregion

        #region 'Public Methods'
        [Route("")]
        [HttpGet]
        public ActionResult TakeAll()
        {
            //retorna todos os dadaos da tabela Spells
            try
            {
                return Ok(_data.Spells);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{SpellId}")]
        [HttpGet]
        public ActionResult TakeById(int SpellId)
        {
            try
            {
                return Ok(_data.Spells.Find(SpellId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("TakeByLevel/{SpellLevel}")]
        [HttpGet]
        public ActionResult SpellLevel(int SpellLevel)
        {
            try
            {                
                return Ok(_data.Spells.Where(resp => resp.SpellLevel == SpellLevel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("")]
        [HttpPost]
        public ActionResult Create([FromBody] Spells model)
        {
            try
            {
                _data.Spells.Add(model);
                _data.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{SpellId}")]
        [HttpPut]
        public ActionResult Update(int SpellID, Spells model)
        {
            try
            {
                model.SpellId = SpellID;
                _data.Spells.Update(model);
                _data.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{SpellId}")]
        [HttpDelete]
        public ActionResult Delete(int SpellID)
        {
            try
            {
                _data.Spells.Remove(_data.Spells.Find(SpellID));
                _data.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("lerTxt")]
        [HttpPost]
        public void LerTxt()
        {
            var text = System.IO.File.ReadAllText(@"C:\TextProject\teste.txt");
            var wordWrap = text.Split("\n");
            var spell = new Spells();

            foreach (string roll in wordWrap)
            {
                var rollTrim = roll.Trim();
                string pattern;
                pattern = "([A-Z])";
                if (!Regex.IsMatch(rollTrim, pattern))
                {
                    pattern = "([a-z])";
                    if (!Regex.IsMatch(rollTrim, pattern))
                    {
                        continue;
                    }
                }
                #region 'SpellName'
                //Testa se é uma SpellName
                pattern = "([a-z])";
                if (!Regex.IsMatch(rollTrim, pattern))
                {
                    if (spell.SpellName != null)
                    {
                        
                        _data.Spells.Add(spell);
                        _data.SaveChanges();

                        spell = new Spells();

                    }
                    spell.SpellName = rollTrim;
                    continue;
                }
                #endregion

                #region 'SpellLevel'
                //Testa se é uma spellLevel
                pattern = "Truque de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 0;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }

                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "1° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 1;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "2° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 2;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "3° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 3;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "4° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 4;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "5° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 5;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "6° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 6;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "7° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 7;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "8° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 8;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }

                pattern = "9° nível de";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    spell.SpellLevel = 9;
                    var ritual = "(ritual)";
                    if (Regex.IsMatch(rollTrim, ritual))
                    {
                        spell.SpellRitual = 1;
                        rollTrim = rollTrim.Replace(ritual, string.Empty);
                    }
                    else
                    {
                        spell.SpellRitual = 0;
                    }
                    rollTrim = rollTrim.Replace(pattern, string.Empty).Replace(" ", string.Empty);
                    spell.SpellSchool = rollTrim;
                    continue;
                }
                #endregion

                #region 'SpellConjurationTime/SpellConjurationTimer'
                pattern = "Tempo de Conjuração:";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    pattern = "([0-9])";
                    Match match;
                    string spellConjurationTime = null;
                    while (Regex.IsMatch(rollTrim, pattern))
                    {
                        match = Regex.Match(rollTrim, pattern);
                        spellConjurationTime = spellConjurationTime + match.Value;
                        rollTrim = rollTrim.Replace(match.Value, string.Empty); ;
                    }                    
                    spell.SpellConjurationTime = Convert.ToInt32(spellConjurationTime);
                    
                    var conTimerRoll = rollTrim.Replace("Tempo de Conjuração:", string.Empty).Replace(" ", string.Empty);
                    pattern = "[0-9]";
                    Regex regex = new Regex(pattern);
                    var onlyChar = regex.Replace(conTimerRoll, string.Empty);

                    switch (onlyChar)
                    {
                        case "ação":
                            spell.SpellConjurationTimer = 1;
                            break;
                        case "açãobônus":
                            spell.SpellConjurationTimer = 2;
                            break;
                        case "minutos":
                            spell.SpellConjurationTimer = 3;
                            break;
                        case "minuto":
                            spell.SpellConjurationTimer = 3;
                            break;
                        case "horas":
                            spell.SpellConjurationTimer = 4;
                            break;
                        case "hora":
                            spell.SpellConjurationTimer = 4;
                            break;
                    }

                    continue;
                }
                #endregion

                #region 'SpellRange'

                pattern = "Alcance: ";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    rollTrim = rollTrim.Replace(pattern, string.Empty);
                    spell.SpellRange = rollTrim;                 
                    continue;
                }

                #endregion

                #region 'Components'
                if (!Regex.IsMatch(rollTrim, "Duração:") && spell.SpellDuration == null)
                {
                    pattern = "Componentes:";
                    if (Regex.IsMatch(rollTrim, pattern))
                    {
                        pattern = "([V])";
                        if (Regex.IsMatch(rollTrim, pattern))
                        {
                            spell.SpellComponentVerbal = 1;
                        }
                        else
                        {
                            spell.SpellComponentVerbal = 0;
                        }

                        pattern = "([S])";
                        if (Regex.IsMatch(rollTrim, pattern))
                        {
                            spell.SpellComponentSomatic = 1;
                        }
                        else
                        {
                            spell.SpellComponentSomatic = 0;
                        }

                        pattern = "M ";
                        if (Regex.IsMatch(rollTrim, pattern))
                        {
                            spell.SpellComponentMaterial = 1;
                            string material = rollTrim.Split("(")[0];
                            material = rollTrim.Replace(material, string.Empty).Replace(")", string.Empty).Replace("(", string.Empty);

                            spell.SpellComponentMaterialDesc = material;
                            continue;
                        }
                        else
                        {
                            spell.SpellComponentMaterial = 0;
                            spell.SpellComponentMaterialDesc = null;
                            continue;
                        }

                    }
                    spell.SpellComponentMaterialDesc = spell.SpellComponentMaterialDesc + rollTrim.Replace(")", string.Empty);
                    continue;
                }

                #endregion

                #region 'Duration/Concentration'
                pattern = "Duração: ";
                if (Regex.IsMatch(rollTrim, pattern))
                {
                    if (Regex.IsMatch(rollTrim, "Instantânea"))
                    {
                        spell.SpellDuration = "Instantânea";
                        continue;
                    }
                    if (Regex.IsMatch(rollTrim, "Concentração"))
                    {
                        spell.SpellConcentration = 1;
                        rollTrim = rollTrim.Replace("Concentração", string.Empty);
                    }else
                    {
                        spell.SpellConcentration = 0;
                    }

                    spell.SpellDuration = rollTrim.Replace(pattern, string.Empty).Replace(",", string.Empty);
                    continue;
                }
                #endregion

                spell.SpellDescription = spell.SpellDescription + " " + rollTrim;
            }

            _data.Spells.Add(spell);
            _data.SaveChanges();

        }
        #endregion
    }
}

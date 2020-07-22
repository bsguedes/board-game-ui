using BoardGameClient.CE.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BoardGameClient.CE.Model
{
    public class CEVersionData
    {
        public CEAbility[] Abilities { get; set; }
        public CECard[] Cards { get; set; }
        public CEBonusCard[] Bonus { get; set; }
        public CEObjective[] Objectives { get; set; }
        public CEChampion[] Champions { get; set; }        

        public static CEVersionData Load()
        {
            byte[] aa = Properties.CEResources.v1;
            MemoryStream MS = new MemoryStream(aa);
            StreamReader sr = new StreamReader(MS, Encoding.Default);
            string content = sr.ReadToEnd();
            CEVersionData data = JsonSerializer.Deserialize<CEVersionData>(content);
            return data;
        }
    }

    public class CEAbility
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Expansion { get; set; }
    }

    public class CETalent
    {
        public string Type { get; set; }        

        public string NormalizedType => new string(Type.Skip(1).Take(2).ToArray());

        public bool IsSelected { get; set; }
    }

    public class CECard
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool TopRow { get; set; }
        public bool MidRow { get; set; }
        public bool BottomRow { get; set; }
        public int Cash { get; set; }
        public string Attribute { get; set; }
        public int Points { get; set; }
        public string CE { get; set; }
        public int Year { get; set; }
        public int AbilityID { get; set; }
        public Dictionary<string, float> Cost { get; set; }
        public string Gender { get; set; }
        public string Lore { get; set; }
        public string ImgPath { get; set; }

        public int ProgrammingCode => (TopRow ? 4 : 0) + (MidRow ? 2 : 0) + (BottomRow ? 1 : 0);
        public string CashRepresentation => new string(Enumerable.Range(0, Cash).Select(x => '$').ToArray());
        public string AbilityType => CEViewModel.GameData.Abilities.First(x => x.ID == AbilityID).Type;
        public string AbilityText => $"{CEViewModel.GameData.Abilities.First(x => x.ID == AbilityID).Type.ToUpper()}: {CEViewModel.GameData.Abilities.First(x => x.ID == AbilityID).Text}";
        public string PhotoPath => $"_{ImgPath.Split('.')[0]}";
        public string CostString
        {
            get
            {
                string[] talents = Cost.Select(d => Enumerable.Repeat(d.Key, (int)Math.Ceiling(d.Value))).SelectMany(x => x).Select( y => "{" + y + "}").ToArray();
                if (Cost.Values.All(x => x < 1))
                {
                    return string.Join(" / ", talents);
                }
                else
                {
                    return string.Join(" + ", talents);
                }
            }
        }

        public bool IsSelected { get; set; }
    }

    public class CEBonusCard
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Criterion { get; set; }
        public string Range1 { get; set; }
        public int ScoreRange1 { get; set; }
        public string Range2 { get; set; }
        public int ScoreRange2 { get; set; }
        public int ScoreRangeCard { get; set; }

        public bool IsRangeMode => ScoreRange1 > 0 && ScoreRange2 > 0;
        public bool IsCountMode => ScoreRangeCard > 0;

        public bool IsSelected { get; set; }
    }

    public class CEObjective
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    public class CEChampion
    {
        public int Level { get; set; }
        public string Channel { get; set; }
        public string Champion { get; set; }
        public int Points { get; set; }
        public int CashCost { get; set; }
        public int CardCost { get; set; }
        public Dictionary<string, int> TalentCost { get; set; }
        public int AbilityID { get; set; }
        public string AbilityName { get; set; }

        public string AbilityType => CEViewModel.GameData.Abilities.First(x => x.ID == AbilityID).Type;
        public string AbilityText
        {
            get
            {
                CEAbility ability = CEViewModel.GameData.Abilities.First(x => x.ID == AbilityID);
                if (ability.Type == "Nada")
                {
                    return string.Empty;
                }                
                return $"{ability.Type.ToUpper()}: {ability.Text}";
            }
        }

        public string CostString
        {
            get
            {
                string[] talents = TalentCost.Select(d => Enumerable.Repeat(d.Key, d.Value)).SelectMany(x => x).Select(y => "{" + y + "}").ToArray();
                string[] cashCost = new string[] { new string(Enumerable.Repeat('$', CashCost).ToArray()) };
                string[] cardCost = Enumerable.Repeat("{C}", CardCost).ToArray();                
                return string.Join(" ", talents.Concat(cashCost).Concat(cardCost).Where(x => x != null));
            }
        }

    }
}

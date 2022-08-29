using BoardGameClient.CE.Controls;
using BoardGameClient.CE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace BoardGameClient.CE.ViewModels
{
    public class ProgrammingRowViewModel : ViewModelBase
    {

    }

    public class RowModel
    {
        public int Position { get; set; }
        public bool HasOptional { get; set; }
        public CECard Card { get; set; }
        public string SlotReward { get; set; }
        public string SlotOptional { get; set; }
        public RowResource Resource { get; set; }
        public bool HasCard => Card != null;
        public CEBoardSlotDescriptor Slot { get; set; }

        public RowModel(int i, CEBoardSlotDescriptor slot)
        {
            Position = i;
            Card = slot.CardObject;
            Slot = slot;
        }

        public RowModel(int i, RowResource resource)
        {
            HasOptional = i % 2 == 1;
            Position = i;
            Resource = resource;
            SlotReward = slotRewardDict[resource][i];
            SlotOptional = slotOptionalDict[resource][i];
        }

        readonly Dictionary<RowResource, Dictionary<int, string>> slotOptionalDict = new Dictionary<RowResource, Dictionary<int, string>>()
        {
            {  RowResource.Talents, new Dictionary<int, string>() {
                { 0, "" }, { 1, "{C} {ra} {D}" }, { 2, "" }, { 3, "{C} {ra} {D}" }, { 4, "" }
            } },
            {  RowResource.Cash, new Dictionary<int, string>() {
                { 0, "" }, { 1, "{X} {ra} $" }, { 2, "" }, { 3, "{X} {ra} $" }, { 4, "" }
            } },
            {  RowResource.Cards, new Dictionary<int, string>() {
                { 0, "" }, { 1, "$ {ra} {C}" }, { 2, "" }, { 3, "$ {ra} {C}" }, { 4, "" }
            } }
        };

        readonly Dictionary<RowResource, Dictionary<int, string>> slotRewardDict = new Dictionary<RowResource, Dictionary<int, string>>()
        {
            {  RowResource.Talents, new Dictionary<int, string>() { 
                { 0, "{D}" }, { 1, "{D}" }, { 2, "{D} {D}" }, { 3, "{D} {D}" }, { 4, "{D} {D} {D}" }
            } },
            {  RowResource.Cash, new Dictionary<int, string>() {
                { 0, "$ $" }, { 1, "$ $" }, { 2, "$ $ $" }, { 3, "$ $ $" }, { 4, "$ $ $ $" }
            } },
            {  RowResource.Cards, new Dictionary<int, string>() {
                { 0, "{C}" }, { 1, "{C}" }, { 2, "{C} {C}" }, { 3, "{C} {C}" }, { 4, "{C} {C} {C}" }
            } }
        };
        
    }
}

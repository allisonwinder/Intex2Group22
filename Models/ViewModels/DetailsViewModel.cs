using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intex2Group22.Models.ViewModels
{
    public class DetailsViewModel
    {
        public Burialmain burial { get; set; }

        public List<Textile> textiles { get; set; }

        public List<Color> colors { get; set; }

        public List<ColorTextile> coltexts { get; set; }

        public List<StructureTextile> structexts { get; set; }

        public List <Structure> structures { get; set; }

        public List<TextilefunctionTextile> functstexts { get; set; }

        public List<Textilefunction> textilefunctions { get; set; }

        public List<Bodyanalysischart> charts { get; set; }

        public DetailsViewModel(Burialmain burialIn, List<Textile> textileList, List<Color> colorList, 
            List<ColorTextile> coltextsList, List<StructureTextile> structextsList, 
            List<Structure> structuresList, List<TextilefunctionTextile> functstextsList, 
            List<Textilefunction> textilefunctionsList, List<Bodyanalysischart> chartsList)
        {
            burial = burialIn;
            textiles = textileList;
            colors = colorList;
            coltexts = coltextsList;
            structexts = structextsList;
            structures = structuresList;
            functstexts = functstextsList;
            textilefunctions = textilefunctionsList;
            charts = chartsList;

        }
    }
}

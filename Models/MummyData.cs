using Microsoft.ML.OnnxRuntime.Tensors;

namespace Intex2Group22.Models
{
    public class MummyData
    {
        public float Sex_M { get; set; }
        public float EastWest_W { get; set; }
        public float AdultSubadult_C { get; set; }
        public float Preservation_SKELETON { get; set; }
        public float Preservation_poorly_preserved { get; set; }
        public float Preservation_skeletalized { get; set; }
        public float Wrapping_H { get; set; }
        public float Wrapping_W { get; set; }
        public float HairColor_B { get; set; }
        public float HairColor_D { get; set; }
        public float SamplesCollected_true { get; set; }
        public float Area_SE { get; set; }
        public float Area_SW { get; set; }
        public float AgeAtDeath_C { get; set; }
        public float AgeAtDeath_N { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                Sex_M, EastWest_W, AdultSubadult_C, Preservation_SKELETON, Preservation_poorly_preserved, Preservation_skeletalized, Wrapping_H,
                Wrapping_W, HairColor_B, HairColor_D, SamplesCollected_true, Area_SE, Area_SW, AgeAtDeath_C, AgeAtDeath_N
            };
            int[] dimensions = new int[] { 1, 15 };
            return new DenseTensor<float>(data, dimensions);
        }

    }
}


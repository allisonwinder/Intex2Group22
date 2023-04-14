using System.Collections.Generic;
using System.Linq;
using Intex2Group22.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Intex2Group22.Controllers
{
    [ApiController]
    [Route("/predict")]

    public class OnnxController : ControllerBase
    {
        private InferenceSession _session;

        public OnnxController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(MummyData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}

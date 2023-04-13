using Intex2Group22.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Intex2Group22.Core.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}

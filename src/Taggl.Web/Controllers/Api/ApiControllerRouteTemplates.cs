using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Web.Controllers
{
    public static class ApiControllerRouteTemplates
    {
        private const string RootRouteTemplate = "api";

        #region Professionalities

        private const string ProfessionalitiesRouteTemplate = RootRouteTemplate + "/professions";
        public const string ProfessionalityRouteTemplate = ProfessionalitiesRouteTemplate;
        public const string ExpertiseRouteTemplate = ProfessionalityRouteTemplate + "/expertise";

        #endregion

    }
}

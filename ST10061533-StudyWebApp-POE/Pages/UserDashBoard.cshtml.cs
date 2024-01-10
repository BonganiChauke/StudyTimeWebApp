using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class UserDashBoardModel : PageModel
    {
        
        public string userName = "";
        public int Module_ID, selfHours;


        public void OnGet()
        {
            userName = Request.Query["userName"];
            Module_ID = Convert.ToInt32(Request.Query["Module_ID"]);
            selfHours = Convert.ToInt32(Request.Query["selfStudy_hoursPerWeek"]);
        }
    }
}

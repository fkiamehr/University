using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.Core.Services.Interfaces;
using University.DataLayer.Entities;

namespace University.Web.Pages.Students
{
    public class CreateStudentsModel : PageModel
    {
        private IStudentService _studentService;
        public CreateStudentsModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [BindProperty]
        public Student Student { get; set; }
        void dropdown()
        {
            var levels = _studentService.GetLevelsForManageStudent();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text");
        }
        public void OnGet()
        {
            dropdown();
        }
        public IActionResult Post()
        {

            if (!ModelState.IsValid)
            {
                dropdown();
                return Page();
            }
               

            _studentService.AddStudent(Student);

            return RedirectToPage("Index");
        }
    }
}

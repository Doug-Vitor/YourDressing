using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Components
{
    public class SectionMenu : ViewComponent
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionMenu(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _sectionRepository.GetAllAsync());
        }
    }
}

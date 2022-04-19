using AutoMapper;
using HT.Presentation.Models;
using HT.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HT.Presentation.Controllers
{
    public class HarmonicaController : Controller
    {
        private readonly ILogger<HarmonicaController> _logger;
        private readonly IHarmonicaService _harmonicaService;
        private readonly IMapper _mapper;

        public HarmonicaController(ILogger<HarmonicaController> logger, IHarmonicaService harmonicaService, IMapper mapper)
        {
            _logger = logger;
            _harmonicaService = harmonicaService;
            _mapper = mapper;
        }

        public IActionResult Index(HarmonicaViewModel model)
        {
            if (!ModelState.IsValid)
                model = _mapper.Map<HarmonicaViewModel>(_harmonicaService.GetAllHolesNotesOnly());

            return View(model);
        }

        public IActionResult Settings(ScaleViewModel scaleView)
        {
            return View(scaleView);
        }

        [HttpPost]
        public IActionResult ChangeTune(ScaleViewModel scaleView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _harmonicaService.SetTone(scaleView.Tone, scaleView.Pitch);

                    HarmonicaViewModel model = _mapper.Map<HarmonicaViewModel>(_harmonicaService.GetAllHolesNotesOnly());

                    return View("Index", model);
                }

                TempData["ErrorMessage"] = $"Failed to change tune.";
                return View("Index", _mapper.Map<HarmonicaViewModel>(_harmonicaService.GetAllHolesNotesOnly()));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to change tune. {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
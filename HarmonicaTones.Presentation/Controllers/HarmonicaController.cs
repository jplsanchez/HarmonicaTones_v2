using AutoMapper;
using HT.Domain.Entities.Enums.Scales;
using HT.Presentation.Models;
using HT.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HT.Presentation.Controllers
{
    public class HarmonicaController : Controller
    {
        private readonly ILogger<HarmonicaController> _logger;
        private readonly IHarmonicaService _harmonicaService;
        private readonly IScalesService _scaleService;
        private readonly IMapper _mapper;

        public HarmonicaController(ILogger<HarmonicaController> logger, IHarmonicaService harmonicaService, IMapper mapper, IScalesService scaleService)
        {
            _logger = logger;
            _harmonicaService = harmonicaService;
            _mapper = mapper;
            _scaleService = scaleService;
        }

        public IActionResult Index(HarmonicaViewModel model)
        {
            if (!ModelState.IsValid)
                model = _mapper.Map<HarmonicaViewModel>(_harmonicaService.GetAllHolesNotesOnly());

            ViewBag.NotesList = Enum.GetNames(typeof(Chromatic)).ToList();

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

                    var scale = (List<string>)_scaleService.GetNotesFromScale(scaleView.Scale);

                    for (int i = 0; i < model.BlowNotes.Count; i++)
                    {
                        model.BlowNotes[i] = (model.BlowNotes[i].Item1, scale.Contains(model.BlowNotes[i].Item1));
                        model.DrawNotes[i] = (model.DrawNotes[i].Item1, scale.Contains(model.DrawNotes[i].Item1));
                        model.Bend1Notes[i] = (model.Bend1Notes[i].Item1, scale.Contains(model.Bend1Notes[i].Item1));
                        model.Bend2Notes[i] = (model.Bend2Notes[i].Item1, scale.Contains(model.Bend2Notes[i].Item1));
                        model.Bend3Notes[i] = (model.Bend3Notes[i].Item1, scale.Contains(model.Bend3Notes[i].Item1));
                    }

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
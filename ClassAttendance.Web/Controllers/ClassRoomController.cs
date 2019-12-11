using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassAttendance.BLL.Interfaces;
using ClassAttendance.Models.Models;
using ClassAttendance.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassAttendance.Web.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService, IMapper mapper)
        {
            _classRoomService = classRoomService;
            _mapper = mapper;
        }

        [HttpGet("classRooms")]
        public IActionResult GetAll(Guid EDId)
        {
            var classRoomsViewModel =_mapper.Map<IEnumerable<ClassRoom>, IEnumerable<ClassRoomViewModelCreate>>(
                    _classRoomService.GetAllClassRoomsByEducationalInstitutionId(EDId));

            return View(classRoomsViewModel);
        }
    }
}
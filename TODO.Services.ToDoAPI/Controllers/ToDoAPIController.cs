using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TODO.Services.ToDoAPI.Data;
using TODO.Services.ToDoAPI.Models;
using TODO.Services.ToDoAPI.Models.Dto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TODO.Services.ToDoAPI.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoAPIController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;


        public ToDoAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<ToDo> objList = _db.ToDos.ToList();
                _response.Result = _mapper.Map<IEnumerable<ToDoDto>>(objList);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                ToDo obj = _db.ToDos.First(u => u.ToDoId == id);
                _response.Result = _mapper.Map<ToDoDto>(obj);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPost]        
        public ResponseDto Post([FromBody] ToDoDto toDoDto)
        {
            try
            {
                ToDo obj = _mapper.Map<ToDo>(toDoDto);
                _db.ToDos.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ToDoDto>(obj);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPut]        
        public ResponseDto Put([FromBody] ToDoDto toDoDto)
        {
            try
            {
                ToDo obj = _mapper.Map<ToDo>(toDoDto);
                _db.ToDos.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ToDoDto>(obj);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]       
        public ResponseDto Delete(int id)
        {
            try
            {
                ToDo obj = _db.ToDos.First(u => u.ToDoId == id);
                _db.ToDos.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}


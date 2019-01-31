using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCorePrac1.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCorePrac1.Controllers
{
    public class OperationsController : Controller
    {
        private readonly OperationService _operationService;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;


        //Asp.Net Core will automatically populate controller constructor arugments by resolving services from the DI container.
        //If needed, those objects will be created by calling constructors
        //whose own arguments will be provided by DI, and so on recursively until the whole object graph
        //needed has to be constructed

        public OperationsController(OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation)
        {
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
        }

        [HttpGet]
        [Route("operations/index")]
        public IActionResult Index()

        {
            // viewbag contains controller-requested services
            ViewBag.Transient = _transientOperation.OperationId;
            ViewBag.Scoped = _scopedOperation.OperationId;
            ViewBag.Singleton = _singletonOperation.OperationId;
            ViewBag.SingletonInstance = _singletonInstanceOperation.OperationId;

            // operation service has its own requested services
            ViewBag.Servicea = _operationService.TransientOperation.OperationId;
            ViewBag.Serviceb = _operationService.ScopedOperation.OperationId;
            ViewBag.Servicec = _operationService.SingletonOperation.OperationId;
            ViewBag.Serviced = _operationService.SingletonInstanceOperation.OperationId;

            return View();
        }
    }
}
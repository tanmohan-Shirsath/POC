"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var nyse_service_1 = require("./nyse.service");
describe('NyseService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(nyse_service_1.NyseService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=nyse.service.spec.js.map
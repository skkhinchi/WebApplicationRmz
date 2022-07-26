﻿using System;
using System.Collections.Generic;
using WebApplicationRmz.Model;
using WebApplicationRmz.Models;

namespace WebApplicationRmz.Service.ElectricityMeterService
{
    public interface IElectricityMeterService
    {
        //  List<ElectricityMeter> GetAll();
        // List<ElectricityMeter> GetElectricityMeterById(int id);
        //List<ElectricityMeter> AddElectricityMeter(ElectricityMeter electricityMeter);

        //  IEnumerable<ElectricityMeter> GetAll();
        //  ElectricityMeter AddElectricityMeter(ElectricityMeter electricityMeter);
        //  ElectricityMeter GetElectricityMeterById(int id);
        ////  void Delete(int id);
        //  ElectricityMeterDetails GetMeterDetails(int id);

        IEnumerable<ElectricityMeter> GetAllItems();
        ElectricityMeter Add(ElectricityMeter newItem);

        ElectricityMeter GetById(Guid id);

        //ElectricityMeterDetails GetFullDetails(Guid id);



    }
}

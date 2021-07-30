using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using IndianCensusAnalyser.DTO;
using IndianCensusAnalyser;

namespace UnitTestForIndianCensus
{
    [TestClass]
    public class UnitTest1
    {
        
        string stateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateData.csv";
        string wrongTypeStateCodePath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCensusPath = @"C:\Users\saivijayakumar.b\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";

        IndianCensusAnalyser.CSVAdapterFactory CSV = null;
        Dictionary<string, CensusDTO> totalRecords;

        [TestInitialize]
        public void SetUp()
        {
            CSV = new IndianCensusAnalyser.CSVAdapterFactory();
            totalRecords = new Dictionary<string, CensusDTO>();
        }
        //TC 1.1
        [TestMethod]
        [TestCategory("Use Case 1")]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            totalRecords = CSV.LoadCsvData(IndianCensusAnalyser.CensusAnalyser.Country.INDIA,stateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm");
            Assert.AreEqual(7, totalRecords.Count);
        }
        //TC 1.2
        [TestMethod]
        [TestCategory("Use Case 1")]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        //TC 1.3
        [TestMethod]
        [TestCategory("Use Case 1")]
        public void GivenWrongTypeReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNO,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        //TC 1.4
        [TestMethod]
        [TestCategory("Use Case 1")]
        public void GivenWrongDelimeterReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        //TC 1.5
        [TestMethod]
        [TestCategory("Use Case 1")]
        public void GivenWrongHeaderReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => CSV.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqkm,DensityPerSqkm"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
    }
}
 
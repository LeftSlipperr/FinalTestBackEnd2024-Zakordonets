using AutoMapper;
using BankSystemApp.Interfaces;
using BuildingSystem.Data.Storage;
using BuildingSystem.Domain.Models;

namespace BankSystemApp.Services;

public class SensorDataService : ISensorDataService
{
    private readonly SensorDataStorage _storage;
    private readonly IMapper _mapper;

    public SensorDataService(SensorDataStorage storage, IMapper mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task AddAsync(SensorData sensorData, CancellationToken cancellationToken)
    {
        if (sensorData.Timestamp == default)
            throw new ArgumentException("Неверная временная метка.", nameof(sensorData.Timestamp));
        
        await _storage.AddAsync(sensorData);
    }

    public async Task<IEnumerable<SensorData>> GetBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
    {
        var data = await _storage.GetBySensorIdAndDateRangeAsync(sensorId, startDate, endDate);
        return data;
    }
}
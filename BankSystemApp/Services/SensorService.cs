using AutoMapper;
using BankSystemApp.Interfaces;
using BuildingSystem.Data.Storage;
using BuildingSystem.Domain.Models;

namespace BankSystemApp.Services;

public class SensorService : ISensorService
{
    private readonly SensorStorage _storage;
    private readonly IMapper _mapper;

    public SensorService(SensorStorage storage, IMapper mapper)
    {
        _storage = storage;
        _mapper = mapper;
    }

    public async Task AddAsync(Sensor sensor, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(sensor.Name))
            throw new ArgumentException("Имя датчика не может быть пустым.", nameof(sensor.Name));

        var sensors = _mapper.Map<Sensor>(sensor);
    }

    public async Task UpdateAsync(Sensor sensor, CancellationToken cancellationToken)
    {
        var sensors = await _storage.GetByIdAsync(sensor.Id);
        if (sensors == null)
            throw new KeyNotFoundException($"Датчик с ID {sensors.Id} не найден.");
        
        await _storage.UpdateAsync(sensors);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _storage.DeleteAsync(id);
    }

    public async Task<Sensor> GetByIdAsync(Guid sensorId, CancellationToken cancellationToken)
    {
        return await _storage.GetByIdAsync(sensorId);
    }

    public async Task<IEnumerable<Sensor>> GetByBuildingIdAsync(Guid buildingId, CancellationToken cancellationToken)
    {
        var sensors = await _storage.GetByBuildingIdAsync(buildingId);
        return sensors;
    }
}
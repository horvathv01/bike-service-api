using System.ComponentModel.DataAnnotations.Schema;
using BikeServiceAPI.Enums;
using BikeServiceAPI.Models.DTOs;

namespace BikeServiceAPI.Models.Entities;

public class Bike
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string VIN { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public BikeType BikeType { get; set; }
    public int WheelSize { get; set; }
    public BikeFrameSize FrameSize { get; set; }
    public BikeState State { get; set; }
    public long UserId { get; set; }
    public List<ServiceEvent> ServiceHistory { get; set; } = new List<ServiceEvent>();
    public bool Insured { get; set; }

    public Bike()
    {
        
    }
    public Bike(BikeDto dto)
    {
        Id = dto.Id;
        VIN = dto.VIN;
        Manufacturer = dto.Manufacturer;
        Model = dto.Model;
        BikeType = Enum.Parse<BikeType>(dto.BikeType);
        WheelSize = dto.WheelSize;
        FrameSize = Enum.Parse<BikeFrameSize>(dto.FrameSize);
        State = Enum.Parse<BikeState>(dto.State);
        UserId = dto.UserId;
        Insured = dto.Insured;
    }

    public override string ToString()
    {
        return
            $"VIN: {VIN}, Insured: {Insured}, Manufacturer: {Manufacturer}, Model: {Model}, BikeType: {BikeType.ToString()}, Wheel size: {WheelSize}.";
    }
}
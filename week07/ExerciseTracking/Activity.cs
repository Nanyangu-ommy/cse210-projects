// Activity.cs
using System;
using System.Globalization;

// --- Base Class ---

public abstract class Activity
{
    // Encapsulated private backing fields
    private DateTime _date;
    private double _durationMinutes;
    private string _activityType;

    // Public properties (Read-only access)
    public DateTime Date => _date;
    public double DurationMinutes => _durationMinutes;
    public string ActivityType => _activityType;

    public Activity(DateTime date, double durationMinutes, string activityType)
    {
        _date = date;
        _durationMinutes = durationMinutes;
        _activityType = activityType;
    }

    // --- Calculation Methods ---
    
    // Abstract method: MUST be implemented by derived classes to provide distance.
    protected abstract double GetDistanceMiles();

    // Virtual method: Uses GetDistanceMiles() and can be overridden (e.g., in Cycling).
    protected virtual double GetSpeedMph()
    {
        double distance = GetDistanceMiles();
        // Speed (mph) = (distance / minutes) * 60
        return DurationMinutes == 0 ? 0.0 : (distance / DurationMinutes) * 60;
    }

    // Virtual method: Uses GetDistanceMiles() and can be overridden (e.g., in Cycling).
    protected virtual double GetPaceMinPerMile()
    {
        double distance = GetDistanceMiles();
        // Pace (min per mile) = minutes / distance
        return distance == 0 ? 0.0 : DurationMinutes / distance;
    }

    // --- Summary Method (Defined in base class, uses polymorphism) ---
    
    public string GetSummary()
    {
        double distance = GetDistanceMiles();
        double speed = GetSpeedMph();
        double pace = GetPaceMinPerMile();

        // Format the date as "03 Nov 2022"
        string formattedDate = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

        // Produce the summary string
        return $"{formattedDate} {ActivityType} ({DurationMinutes:F0} min): " +
               $"Distance {distance:F1} miles, " +
               $"Speed {speed:F1} mph, " +
               $"Pace: {pace:F1} min per mile";
    }
}

// --------------------------------------------------------------------------------------------------------------------------------

// --- Derived Class 1: Running ---

public class Running : Activity
{
    private double _distanceMiles; // Encapsulated field

    public Running(DateTime date, double durationMinutes, double distanceMiles)
        : base(date, durationMinutes, "Running")
    {
        _distanceMiles = distanceMiles;
    }

    // Overrides abstract method: Returns the stored distance.
    protected override double GetDistanceMiles()
    {
        return _distanceMiles;
    }
}

// --------------------------------------------------------------------------------------------------------------------------------

// --- Derived Class 2: Stationary Bicycles ---

public class StationaryBicycles : Activity
{
    private double _recordedSpeedMph; // Encapsulated field

    public StationaryBicycles(DateTime date, double durationMinutes, double recordedSpeedMph)
        : base(date, durationMinutes, "Cycling")
    {
        _recordedSpeedMph = recordedSpeedMph;
    }

    // Overrides abstract method: Calculates distance from stored speed.
    protected override double GetDistanceMiles()
    {
        // Distance = Speed * Time (in hours)
        return _recordedSpeedMph * (DurationMinutes / 60.0);
    }

    // Overrides virtual method: Returns the stored speed directly.
    protected override double GetSpeedMph()
    {
        return _recordedSpeedMph;
    }

    // Overrides virtual method: Calculates pace from stored speed (Pace = 60 / Speed).
    protected override double GetPaceMinPerMile()
    {
        return _recordedSpeedMph == 0 ? 0.0 : 60.0 / _recordedSpeedMph;
    }
}

// --------------------------------------------------------------------------------------------------------------------------------

// --- Derived Class 3: Swimming ---

public class Swimming : Activity
{
    private int _numLaps; // Encapsulated field

    public Swimming(DateTime date, double durationMinutes, int numLaps)
        : base(date, durationMinutes, "Swimming")
    {
        _numLaps = numLaps;
    }

    // Overrides abstract method: Calculates distance from laps.
    protected override double GetDistanceMiles()
    {
        // Distance (km) = laps * 50 / 1000
        double distanceKm = (_numLaps * Constants.LapLengthMeters) / 1000.0;
        // Distance (miles) = Distance (km) * KM_TO_MILE
        return distanceKm * Constants.KmToMile;
    }
}
namespace SwedishHoliday

open System

/// <summary>
/// Functions to check if a date is a swedish holiday.
/// </summary>
module Holiday =

    /// <summary>
    /// Checks if the date is a holiday in january.
    ///
    /// January holidays are new years day (1 jan) and epiphany (6 jan)
    /// </summary>
    let IsJanuaryHoliday (date: DateTime) =
        if date.Month <> 1 then
            false
        else
            match date.Day with
            | 1 -> true
            | 6 -> true
            | _ -> false

    /// <summary>
    /// Checks if the date is a holiday in may.
    ///
    /// May holidays are may 1
    /// </summary>
    let IsMayHoliday (date: DateTime) =
        if date.Month <> 5 then
            false
        else
            match date.Day with
            | 1 -> true
            | _ -> false

    /// <summary>
    /// Checks if the date is a holiday in june.
    ///
    /// June holidays are the swedish national day (6 june)
    /// </summary>
    let IsJuneHoliday (date: DateTime) =
        if date.Month <> 6 then
            false
        else
            match date.Day with
            | 6 -> true
            | _ -> false

    /// <summary>
    /// Checks if the date is a holiday in december.
    ///
    /// December holidays are christmas eve (24 dec), christmas day (25 dec),
    /// boxing day (26 dec) and new years eve (31 dec)
    /// </summary>
    let IsDecemberHoliday (date: DateTime) =
        if date.Month <> 12 then
            false
        else
            match date.Day with
            | 24 -> true
            | 25 -> true
            | 26 -> true
            | 31 -> true
            | _ -> false

    /// <summary>
    /// Checks if the date is a easter holiday date.
    /// </summary>
    let IsEasterHoliday (date: DateTime) =
        date |> Easter.IsGoodFriday
        || date |> Easter.IsEasterMonday
        || date |> Easter.IsAscensionDay
        || date |> Easter.IsEasterDay
        || date |> Easter.IsDayOfPentecost

    let private IsMidsummersEve (date: DateTime) =
        if date.Month <> 6 then
            false
        else
            date.Day >= 19 && date.Day <= 25 && date.DayOfWeek = DayOfWeek.Friday

    let private IsMidsummersDay (date: DateTime) =
        if date.Month <> 6 then
            false
        else
            date.Day >= 20 && date.Day <= 26 && date.DayOfWeek = DayOfWeek.Saturday

    /// <summary>
    /// Checks if the date is midsummer.
    /// </summary>
    let IsMidsummer (date: DateTime) =
        date |> IsMidsummersEve || date |> IsMidsummersDay

    /// <summary>
    /// Checks if the date is all saints day.
    /// </summary>
    let IsAllSaintsDay (date: DateTime) =
        if date.Month <> 10 && date.Month <> 11 then
            false
        else
            (date.Day = 31 && date.Month = 10 && date.DayOfWeek = DayOfWeek.Saturday)
            || (date.Day >= 1
                && date.Day <= 6
                && date.Month = 11
                && date.DayOfWeek = DayOfWeek.Saturday)

    /// <summary>
    /// Checks if the date is a swedish holiday.
    /// </summary>
    let IsSwedishHoliday (date: DateTime) =
        date |> IsJanuaryHoliday
        || date |> IsMayHoliday
        || date |> IsJuneHoliday
        || date |> IsDecemberHoliday
        || date |> IsEasterHoliday
        || date |> IsMidsummer
        || date |> IsAllSaintsDay

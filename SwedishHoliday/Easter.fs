namespace SwedishHoliday

open System

module internal Easter =
    let private GetEasterDayForYear year =
        let a = year % 19
        let b = year % 4
        let c = year % 7
        let d = (19 * a + 24) % 30
        let e = (2 * b + 4 * c + 6 * d + 5) % 7
        let day = 22 + d + e

        if day <= 31 then
            DateTime(year, 3, day)
        else
            let aprilDay = day - 31

            if (aprilDay = 26 || aprilDay = 25 && d = 28 && e = 6 && a > 10) then
                DateTime(year, 4, aprilDay - 7)
            else
                DateTime(year, 4, aprilDay)

    let private GetGoodFridayFromEaster (easterDay: DateTime) = easterDay.AddDays(-2)
    
    let private GetEasterMondayFromEaster (easterDay: DateTime) = easterDay.AddDays(1)

    let private GetAscensionDayFromEaster (easterDay: DateTime) = easterDay.AddDays(39)
    
    let private GetDayOfPentecostFromEaster (easterDay: DateTime) = easterDay.AddDays(49)

    let private CheckMonthAndDay (first: DateTime) (second: DateTime) =
        first.Month = second.Month && first.Day = second.Day

    let internal IsEasterDay (date: DateTime) =
        GetEasterDayForYear date.Year
        |> CheckMonthAndDay date
    
    let internal IsGoodFriday (date: DateTime) =
        GetEasterDayForYear date.Year
        |> GetGoodFridayFromEaster
        |> CheckMonthAndDay date

    let internal IsEasterMonday (date: DateTime) =
        GetEasterDayForYear date.Year
        |> GetEasterMondayFromEaster
        |> CheckMonthAndDay date

    let internal IsAscensionDay (date: DateTime) =
        GetEasterDayForYear date.Year
        |> GetAscensionDayFromEaster
        |> CheckMonthAndDay date
        
    let internal IsDayOfPentecost (date: DateTime) =
        GetEasterDayForYear date.Year
        |> GetDayOfPentecostFromEaster
        |> CheckMonthAndDay date

export class Weather{
    constructor(
        public city: string,
        public region: string,
        public country: string,
        public timeZone: string,
        public localTime: string,
        public temp_c: number,
        public windDirection: string,
        public condition: string,
        public conditionIcon: string,
        public wind_kph: number,
        public feelslike_c: number,
        public last_updated: string,
    ){}
}
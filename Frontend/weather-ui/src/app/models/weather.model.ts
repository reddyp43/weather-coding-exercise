export interface Weather {
  date: string;
  minimumTemperature: number | null;
  maximumTemperature: number | null;
  precipitationSum: number | null;
  status: string | null;
  errorMessage: string | null;
}

export interface ErrorResponse {
  id: string;
  title: string;
  message: string;
  details: ErrorDetailsResponse[];
}

export interface ErrorDetailsResponse {
  title: string;
  message: string;
}

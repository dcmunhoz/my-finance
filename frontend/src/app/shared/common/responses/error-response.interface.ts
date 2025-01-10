export interface IErrorResponse {
  id: string;
  title: string;
  message: string;
  details: IErrorDetailsResponse[];
}

export interface IErrorDetailsResponse {
  title: string;
  message: string;
}

export class BaseResponse<T>{
  public success: boolean = false;
  public message: string = "";
  public data: T | null = null;
}

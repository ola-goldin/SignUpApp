import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../users/user.model';
import { BehaviorSubject, Observable, catchError, of, tap } from 'rxjs';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient, private messageService: MessageService) { }

  allUsers = new BehaviorSubject<User[]>([]);

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      const errorMessage = error?.error?.errors?.error?.error?.title || error?.error || 'An error occurred';
      this.messageService.add({ severity: 'error', detail: `${operation} failed: ${JSON.stringify(errorMessage)}` });
      return of(result as T);
    };
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>('/users').pipe(
      tap(x => this.allUsers.next(x)),
      catchError(this.handleError<User[]>('getUsers', []))
    );
  }

  addOrUpdateUser(user: User): Observable<User> {
   
    if (user.id > 0)
      return this.http.put<User>(`/users/${user.id}`, user).pipe(
        catchError(this.handleError<User>('editUser'))
      );
    else return this.http.post<User>('/users', user).pipe(
      catchError(this.handleError<User>('saveUser'))
    );
  }

  deleteUser(id: number): Observable<User> {
    return this.http.delete<User>(`/users/${id}`).pipe(
      catchError(this.handleError<User>('deleteUser'))
    );
  }
}

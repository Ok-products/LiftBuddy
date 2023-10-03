import { Injectable } from '@angular/core';
import { ApiCallsService } from './Utils/api-calls.service';
import { PersonalRecord } from '../Model/PersonalRecord';

@Injectable({
    providedIn: 'root',
})

export class PersonalRecordService {

    private defaultUrl: string = 'api/PersonalRecord';

    constructor(private apiService: ApiCallsService) { }

    public get() {
        return this.apiService.apiGet<PersonalRecord>(this.defaultUrl);
    }

    public addPersonalRecord(personalRecords: PersonalRecord[]) {
        return this.apiService.apiPost<PersonalRecord[]>(this.defaultUrl, personalRecords);
    }

    public updatePersonalRecord(personalRecords: PersonalRecord[]) {
        return this.apiService.apiPut<PersonalRecord[]>(this.defaultUrl, personalRecords);
    }
}

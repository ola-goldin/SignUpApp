import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import {
  NbActionsModule,
  NbLayoutModule,
  NbMenuModule,
  NbSearchModule,
  NbContextMenuModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbThemeModule,
  NbInputModule,
  NbPopoverModule,
  NbTabsetModule,
  NbDatepickerModule,
} from '@nebular/theme';

import { NbEvaIconsModule } from '@nebular/eva-icons';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { MessageService } from 'primeng/api';
const NB_MODULES = [
  NbLayoutModule,
  NbMenuModule,
  NbActionsModule,
  NbInputModule,
  NbSearchModule,
  NbContextMenuModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbEvaIconsModule,
  NbMenuModule,
  NbPopoverModule,
  NbTabsetModule,
  NbActionsModule,
  NbDatepickerModule
];

const PNG_MODULES = [
  TableModule,
  DropdownModule,
  ButtonModule,
  RippleModule,
  InputTextModule,
  CalendarModule,
  ToastModule,
  DynamicDialogModule,
  
];

@NgModule({
  providers:[MessageService],
  imports: [CommonModule, ...NB_MODULES, ...PNG_MODULES],
  exports: [CommonModule,  ...NB_MODULES, ...PNG_MODULES],
  declarations: [],
})
export class ThemeModule {
  static forRoot(): ModuleWithProviders<ThemeModule> {
    return {
      ngModule: ThemeModule,
      providers: [
        DialogService,
        ...(NbThemeModule.forRoot({
          name: 'default',
        }).providers as Array<any>),
      ],
    };
  }
}

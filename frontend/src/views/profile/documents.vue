<template>
  <div>
    <DeskTitle subtitle="Чек-лист">
      <template v-slot:title>
        Мои льготы<br/>и документы
      </template>
    </DeskTitle>
    <v-container>
      <v-row>
        <v-col>
          <template v-for="(items, key, i) in documents">
            <div :key="i" class="text-h5">{{ i + 1 }}. {{ types[key] }}</div>
            <v-list :key="`list-${i}`" class="mb-6">
              <v-list-item v-for="(item, ii) in items" :key="ii" link>
                <v-list-item-action>
                  <v-btn icon>
                    <v-icon :color="item.status ? 'success': ''">
                      mdi-{{ item.status ? 'checkbox-marked-circle-outline' : 'checkbox-blank-outline' }}
                    </v-icon>
                  </v-btn>
                </v-list-item-action>
                <v-list-item-title>
                  {{ item.title }}
                </v-list-item-title>
                <v-list-item-action>
                  {{ items.date }}
                </v-list-item-action>
                <v-list-item-action>
                  <v-btn icon title="Интсрукция" to="/blog/solutions">
                    <v-icon>mdi-file-document-multiple</v-icon>
                  </v-btn>
                </v-list-item-action>
              </v-list-item>
            </v-list>
          </template>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      documents: {
        documents: [
          {
            title: 'Справка №ГС-354',
            date: '10.10.2020',
            status: true,
          },
          {
            title: 'Справка №ГС-354',
            date: '10.10.2020',
            status: false,
          },
        ],
        driver: [
          {
            title: 'Справка №ГС-354',
            date: '10.10.2020',
            status: true,
          },
        ],
        passport: [
          {
            title: 'Справка №ГС-354',
            date: '10.10.2020',
            status: false,
          },
        ],
      },
      types: {
        documents: 'Подтверждение льгот',
        driver: 'Водительские права',
        passport: 'Перевыпуск паспорта',
      }
    }
  },
}
</script>

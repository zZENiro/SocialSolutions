<template>
  <div>
    <DeskTitle image="3" title="Решить проблему" subtitle="Задать вопрос, найти ответ" />
    <v-container class="mt-6">
      <v-row>
        <v-col cols="6" md="4" v-for="(item, i) in items" :key="i" class="">
          <v-card rounded="xl" class="elevation-primary">
            <div class="d-flex pa-3">
              <div class="title primary--text">{{ item.title }}</div>
              <div>
                <v-icon v-if="item.status === 1" color="success">mdi-checkbox-marked-circle-outline</v-icon>
                <v-icon v-else color="">mdi-autorenew</v-icon>
              </div>
            </div>
            <div class="d-flex pa-3 justify-space-between align-baseline">
              <div class="title">{{ item.count }} ответов</div>
              <div class="subtitle text-right">{{ item.status === 1 ? 'Ответ помог' : 'В ожидании решения' }}</div>
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      items: [
        {
          title: 'Как добиться получения льгот для пожилого человека в реалиях пандемии?',
          count: '176',
          status: 1,
        },
        {
          title: 'Как вы решили вопрос с пандусом в подъезде?',
          count: '105',
          status: 0,
        },
        {
          title: 'Совсем недавно потерял ноги... Как теперь построить досуг и найти хобби?',
          count: '650',
          status: 1,
        },
      ],
    }
  },
}
</script>
